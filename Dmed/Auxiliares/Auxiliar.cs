using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed.Auxiliares
{
    public static class Auxiliar
    {
        public static string PrepararCampo(this string campo) => campo.RemoverAcentos().Replace("Ç", "").Replace("ç", "").Replace(".", "").Replace("-", "");

        public static string PrepararCampo(decimal value) => value.ToString("##,0.00").Replace(",", "").Replace(".", ""); 

        private static string RemoverAcentos(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
