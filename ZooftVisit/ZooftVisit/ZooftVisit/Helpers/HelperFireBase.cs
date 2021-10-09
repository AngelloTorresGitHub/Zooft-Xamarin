using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooftVisit.Models;

namespace ZooftVisit.Helpers
{
    public class HelperFireBase
    {
        FirebaseClient firebase = new FirebaseClient("https://zooft-10490-default-rtdb.firebaseio.com/");
        public string lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        //public async Task<List<SubTipo>> GetSubTipos()
        //{
        //    return (await firebase
        //        .Child("subTipos")
        //        .OnceAsync<SubTipo>()).Select(dato => new SubTipo { 
        //            Id = dato.Object.Id,
        //            IdDepartamento = dato.Object.IdDepartamento,
        //            Nivel = dato.Object.Nivel,
        //            DescripcionEsp = dato.Object.DescripcionEsp,
        //            DescripcionIng = dato.Object.DescripcionIng
        //        }).ToList();
        //}

        public async Task<List<SubTipo>> GetSubTipos()
        {
            return (await firebase
                .Child("subTipos")
                .OnceAsync<SubTipo>()).Select(dato => new SubTipo
                {
                    Id = dato.Object.Id,
                    IdDepartamento = dato.Object.IdDepartamento,
                    Nivel = dato.Object.Nivel,
                    DescripcionEsp = dato.Object.DescripcionEsp,
                    DescripcionIng = dato.Object.DescripcionIng
                }).ToList();

            //return (await firebase
            //    .Child("subTipos")
            //    .OnceAsync<SubTipo>()).Select(dato => new SubTipo
            //    {
            //        Id = dato.Object.Id,
            //        IdDepartamento = dato.Object.IdDepartamento,
            //        Nivel = dato.Object.Nivel,
            //        DescripcionEsp = dato.Object.DescripcionEsp,
            //        DescripcionIng = dato.Object.DescripcionIng
            //    }).ToList();         
        }
    }
}
