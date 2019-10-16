using AirBnb.Models;
using MvvmHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AirBnb.ViewModels
{
    public class MainPageViewModel :BaseViewModel
    {
        public string ImageURL { get; set; }
        public string Title { get; set; }

        private List<ExplorerItem> _itens;

        public List<ExplorerItem> Itens
        {
            get { return _itens; }
            set { _itens = value; }
        }


        public MainPageViewModel()
        {
            _itens = new List<ExplorerItem>()
            {
                new ExplorerItem("https://quantocustaviajar.com/blog/wp-content/uploads/2017/01/lugares-mais-bonitos-do-mundo.jpg","Lugares"),
                new ExplorerItem("https://gooutside-static-cdn.akamaized.net/wp-content/uploads/sites/3/2019/10/airbnb-lanca-experiencias-com-animais.jpg","Experiências"),
                new ExplorerItem("https://www.agenciatsuru.com.br/blog/wp-content/uploads/2016/07/marketing-digital-para-turismo-de-aventura-e-ecoturismo.jpg","Aventuras"),
                new ExplorerItem("https://media-cdn.tripadvisor.com/media/photo-s/02/d1/fe/af/getlstd-property-photo.jpg","Restaurantes"),
            };
        }
    }
}
