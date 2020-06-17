using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace proximiti.Helpers
{
    public static class TaskExtensions
    {
        //This method provides a way to allow asyncs
        public static async void SafeFireAndForget (this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }

            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }
    }
}
