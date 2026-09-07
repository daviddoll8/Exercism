using System.Globalization;
using System.Text;

using Xunit.Internal;

public class LedgerEntry(DateTime date, string desc, decimal chg)
{
    public DateTime Date { get; } = date;
    public string Desc { get; } = desc;
    public decimal Chg { get; } = chg;
}

public static class Ledger
{
    public static LedgerEntry CreateEntry(string date, string desc, int chng) =>
        new(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        string curSymb = GetCurrencySymbol(cur);
        (string datPat, int curNeg) = GetLocationInfo(loc);

        var culture = new CultureInfo(loc, false);
        culture.NumberFormat.CurrencySymbol = curSymb!;
        culture.NumberFormat.CurrencyNegativePattern = curNeg;
        culture.DateTimeFormat.ShortDatePattern = datPat!;
        return culture;
    }

    private static (string datPat, int curNeg) GetLocationInfo(string loc) => loc switch
    {
        "nl-NL" => new("dd/MM/yyyy", 12),
        "en-US" => new("MM/dd/yyyy", 0),
        _ => throw new ArgumentException("Invalid Currency")
    };

    private static string GetCurrencySymbol(string cur) => cur switch
    {
        "USD" => "$",
        "EUR" => "€",
        _ => throw new ArgumentException("Invalid Currency")
    };

    private static string PrintHead(string loc) => loc switch
    {
        "en-US" => $"{"Date",-11}| {"Description",-26}| {"Change",-13}",
        "nl-NL" => $"{"Datum",-11}| {"Omschrijving",-26}| {"Verandering",-13}",
        _ => throw new ArgumentException("Invalid locale")
    };

    private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string Description(string desc) => desc.Length <= 25 ? desc : $"{desc[..22]}...";

    private static string Change(IFormatProvider culture, decimal cgh) => cgh switch
    {
        _ when cgh < 0.0m && !cgh.ToString("C", culture).Contains("-") => cgh.ToString("C", culture),
        _ => $"{cgh.ToString("C", culture)} ",
    };

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry) =>
        $"{Date(culture, entry.Date)} | {Description(entry.Desc),-25} | {Change(culture, entry.Chg),13}";

    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries) => entries.OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var formatted = new StringBuilder(PrintHead(locale));
        var culture = CreateCulture(currency, locale);

        sort(entries).ForEach(e => formatted.Append($"\n{PrintEntry(culture, e)}"));
        return formatted.ToString();
    }
}
