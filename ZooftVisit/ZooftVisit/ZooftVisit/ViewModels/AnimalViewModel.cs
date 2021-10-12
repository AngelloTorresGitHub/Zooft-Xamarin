using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZooftVisit.Helpers;
using ZooftVisit.Models;
using ZooftVisit.ViewModels.Base;

namespace ZooftVisit.ViewModels
{
  public class AnimalViewModel : ViewModelBase
    {
        HelperZooft helper = new HelperZooft();

        private Animal _Animal;

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

        public void GetAnimal(String url)
        {
            Task.Run(async () =>
            {
                Animal animal = await helper.GetAnimal(url);
                this.Animal = animal;
            });

        }
    }
}
