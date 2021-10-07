using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZooftVisit.Helpers;
using ZooftVisit.Models;
using ZooftVisit.ViewModels.Base;

namespace ZooftVisit.ViewModels
{
    class AnimalViewModel: ViewModelBase
    {
        HelperAnimal helper = new HelperAnimal();

        public Animal _Animal;

        public Animal Animal
        {
            get
            {
                return this._Animal;
            }
            set
            {
                this._Animal = value;
                OnPropertyChanged("Animal");
            }
        }

        public Animal GetAnimal(String url)
        {
            Animal animal = new Animal();
            Task.Run(async () =>
            {
                animal = await helper.GetAnimal(url);
                this.Animal = animal;
            });

            return animal;
        }
    }
}
