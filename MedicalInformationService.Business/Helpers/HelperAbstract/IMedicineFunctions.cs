using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.Business.Helpers.HelperAbstract
{
    public interface IMedicineFunctions
    {
         Task<bool> CodeControl(string code);
    }
}
