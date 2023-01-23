using DI.Interfaces.KernelInterfaces;
/// <summary>
/// Интерфейс сущности, региструемой в ядре
/// </summary>
internal interface IKernelEntity {
    void KernelInitialize(IKernel kernel);

    /// <summary>
    /// Вызывается при уничтожении ядра.
    /// </summary>
    void KernelDispose();
}