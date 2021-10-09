using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZooftVisit.Models;

namespace ZooftVisit.ViewModels
{
    public class SubTiposViewModel
    {
        FirebaseClient firebase = new FirebaseClient("https://zooft-10490-default-rtdb.firebaseio.com/");

        public async void GetSubtipos()
        {
            var subtipos = (await firebase
                .Child("subTipos")
                .OnceAsync<SubTipo>()).Select(dato => new SubTipo
                {
                    Id = dato.Object.Id,
                    IdDepartamento = dato.Object.IdDepartamento,
                    Nivel = dato.Object.Nivel,
                    DescripcionEsp = dato.Object.DescripcionEsp,
                    DescripcionIng = dato.Object.DescripcionIng
                }).ToList();
        }
    }
}
