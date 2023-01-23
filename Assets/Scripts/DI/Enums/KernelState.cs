namespace DI.Enums {
    public enum KernelState {
        Initial,
        Registered,
        Constructed,
        Run,
        Disposed
    }
    internal static class KernelStateExtensions {
        /// <summary>
        /// Возвращает больший статус из двух.
        /// </summary>
        internal static KernelState GetMax(this KernelState state, KernelState newState) {
            return newState > state ? newState : state;
        }
    }
}