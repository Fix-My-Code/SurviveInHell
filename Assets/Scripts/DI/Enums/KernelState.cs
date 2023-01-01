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
        /// ���������� ������� ������ �� ����.
        /// </summary>
        internal static KernelState GetMax(this KernelState state, KernelState newState) {
            return newState > state ? newState : state;
        }
    }
}