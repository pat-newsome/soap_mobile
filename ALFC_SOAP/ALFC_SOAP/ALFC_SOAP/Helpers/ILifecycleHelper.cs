using System;

namespace ALFC_SOAP
{
    public interface ILifecycleHelper
    {
        event Action Suspending;

        event Action Resuming;
    }
}
