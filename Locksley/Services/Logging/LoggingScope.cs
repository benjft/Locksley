namespace Locksley.Services.Logging;

internal abstract class LoggingScope : IDisposable {
    private readonly LoggingScope? _parent;
    protected LoggingScope? Child;

    public bool IsDisposed { get; private set; } = false;

    protected LoggingScope(LoggingScope parent) : this() {
        _parent = parent;
        _parent.Child = this;
    }

    protected LoggingScope() { }

    public virtual void Dispose() {
        if (!IsDisposed) {
            Child?.Dispose();
            if (_parent != null && _parent.Child == this) {
                _parent.Child = null;
            }

            IsDisposed = true;
        }
        
        GC.SuppressFinalize(this);
    }
}

internal class LoggingScope<TState> : LoggingScope {
    private readonly TState _state;

    public LoggingScope(TState state, LoggingScope parent) : base(parent) {
        _state = state;
    }
    
    public LoggingScope(TState state) {
        _state = state;
    }

    public override string ToString() => $"{_state} => {Child?.ToString() ?? ""}";
}