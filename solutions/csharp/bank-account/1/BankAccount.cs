public class BankAccount
{
    private bool _isOpen;
    private decimal _balance;
    private readonly Lock _lock = new();

    public void Open()
    {
        lock (_lock)
        {
            if (_isOpen)
            {
                throw new InvalidOperationException();
            }
            else
            {
                _isOpen = true;
                _balance = 0m;
            }
        }
    }

    public void Close()
    {
        lock (_lock)
        {
            _isOpen = !_isOpen ? throw new InvalidOperationException() : false;
        }
    }

    public decimal Balance
    {
        get
        {
            lock (_lock)
            {
                return !_isOpen ? throw new InvalidOperationException() : _balance;
            }
        }
    }

    public void Deposit(decimal change)
    {
        lock (_lock)
        {
            if (!_isOpen || change < 0)
                throw new InvalidOperationException();
            else
                _balance += change;
        }
    }

    public void Withdraw(decimal change)
    {
        lock (_lock)
        {
            if (!_isOpen || change < 0 || change > _balance)
                throw new InvalidOperationException();
            else
                _balance -= change;
        }
    }
}
