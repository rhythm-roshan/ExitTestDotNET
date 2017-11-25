using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.CasinoPortal.Shared
{
    public class CasinoPortalValidationResult
    {
        public IList<CasinoPortalValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public CasinoPortalValidationResult(IList<CasinoPortalValidationFailure> failures)
        {
            Errors = failures;
        }

        public CasinoPortalValidationResult()
        {
            Errors = new List<CasinoPortalValidationFailure>();
        }
    }
}
