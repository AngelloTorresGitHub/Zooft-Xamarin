using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ZooftVisit.Helpers;
using ZooftVisit.Models;
using ZooftVisit.ViewModels.Base;

namespace ZooftVisit.ViewModels
{
    public class CoordenadaViewModel : ViewModelBase
    {
        HelperZooft helper = new HelperZooft();

        public ObservableCollection<Coordenada> _Coordenadas;

        public ObservableCollection<Coordenada> Coordenadas
        {
            get
            {
                return this._Coordenadas;
            }
            set 
            {
                this._Coordenadas = value;
                OnPropertyChanged("Coordenadas");
            }
        }

        public List<Coordenada> GetCoordenadas()
        {
            List<Coordenada> coordenadas = new List<Coordenada>();

            Task.Run(async () => {
                coordenadas = await helper.GetCoordenadas();
                this.Coordenadas = new ObservableCollection<Coordenada>(coordenadas);
            });

            return coordenadas;
        }
    }
}
