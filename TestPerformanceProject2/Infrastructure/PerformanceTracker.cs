using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestPerformanceProject2.Infrastructure
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PerformanceTracker
    {
        private static log4net.ILog _log = log4net.LogManager.GetLogger(typeof(PerformanceTracker));
        public PerformanceTracker(ActionInfo info)
        {
            this.actionInfo = info;
        }


        #region Member Variables

        /// <summary>
        /// Hold info about the action being tracked
        /// </summary>
        private ActionInfo actionInfo;

        /// <summary>
        /// Stopwatch to time how long the action took
        /// </summary>
        private Stopwatch stopwatch;


        #endregion


        internal void ProcessActionStart()
        {
            try
            {
                this.stopwatch = Stopwatch.StartNew();
                _log.Debug("Request starting in action => "+ actionInfo.ActionName);
            }
            catch (Exception ex)
            {
                String message = String.Format("Exception {0} occurred PerformanceTracker.ProcessActionStart().  Message {1}\nStackTrace {0}",
                    ex.GetType().FullName, ex.Message, ex.StackTrace);
                Trace.WriteLine(message);
            }
        }



        internal void ProcessActionComplete(bool unhandledExceptionFlag)
        {
            try
            {
                // Stop the stopwatch
                this.stopwatch.Stop();
                _log.Debug("Request finished in "+stopwatch.ElapsedMilliseconds+"ms" );
            }
            catch (Exception ex)
            {
                String message = String.Format("Exception {0} occurred PerformanceTracker.ProcessActionComplete().  Message {1}\nStackTrace {0}",
                    ex.GetType().FullName, ex.Message, ex.StackTrace);
                Trace.WriteLine(message);
            }
        }


    }
}