using AirBnb.Models;
using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AirBnb.ViewModels
{
    public class MainPageViewModel :BaseViewModel
    {
        public string ImageURL { get; set; }
        public string Title { get; set; }
        
        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText , value); }
        }

        private ICommand _searchTextCommand;

        public ICommand SearchTextCommand
        {
            get { return _searchTextCommand; }
            set { SetProperty(ref _searchTextCommand , value); }
        }


        private ObservableCollection<ExplorerItem> _itens;
       

        public ObservableCollection<ExplorerItem> Itens
        {
            get { return _itens; }
            set { SetProperty(ref _itens, value); }
        }

        private ObservableCollection<Solicitacao> _solicitacao;
        public ObservableCollection<Solicitacao> Solicitacao
        {
            get { return _solicitacao; }
            set { SetProperty(ref _solicitacao , value); }
        }

        private ObservableCollection<Solicitacao> _solicitacoesFiltradas;   

        public ObservableCollection<Solicitacao> SolicitacoesFiltradas
        {
            get { return _solicitacoesFiltradas; }
            set { SetProperty(ref _solicitacoesFiltradas , value); }
        }

        private ObservableCollection<Solicitacao> _solicitacoesNaoFiltradas;

        public ObservableCollection<Solicitacao> SolicitacoesNaoFiltradas
        {
            get { return _solicitacoesNaoFiltradas; }
            set { SetProperty(ref _solicitacoesNaoFiltradas,value); }
        }


        public MainPageViewModel()
        {
            _itens = GetItens();
            _solicitacoesNaoFiltradas = GetSolicitacao();
            _solicitacao = _solicitacoesNaoFiltradas;
            _searchTextCommand = new Command(PerformSearch);
        }

        private void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(_searchText))
            {
                _solicitacao = _solicitacoesNaoFiltradas;
            }
            else
            {
                var lista = (_solicitacoesNaoFiltradas
                                                .Where(su => su.Descricao.ToLower()
                                                .Contains(_searchText.ToLower()))).ToList();

                _solicitacoesFiltradas = new ObservableCollection<Solicitacao>(
                                                _solicitacoesNaoFiltradas
                                                .Where(su => su.Descricao.ToLower()
                                                .Contains(_searchText.ToLower())).ToList()
                                        );
                _solicitacao = _solicitacoesFiltradas;
            }
        }

        private static ObservableCollection<Solicitacao> GetSolicitacao()
        {
            return new ObservableCollection<Solicitacao>()
            {
                new Solicitacao{ SolicitacaoId = 1,Usuario="Glauber Marcelino da Silva",DataCadastro = DateTime.Now,Descricao="Solicitacão de Teste 1",Status="pendente" },
                new Solicitacao{ SolicitacaoId = 2,Usuario="Acacia Santos Mota",DataCadastro = DateTime.Now,Descricao="Solicitacão de Teste 2",Status="aprovado" },
                new Solicitacao{ SolicitacaoId = 4,Usuario="Welder",DataCadastro = DateTime.Now,Descricao="Solicitacão de Teste 4" ,Status="aprovado"},
                new Solicitacao{ SolicitacaoId = 3,Usuario="Aline Celestrini",DataCadastro = DateTime.Now,Descricao="Solicitacão de Teste 3",Status="cancelado" }
            };
        }

        private static ObservableCollection<ExplorerItem> GetItens()
        {
            return new ObservableCollection<ExplorerItem>()
            {
                new ExplorerItem("https://quantocustaviajar.com/blog/wp-content/uploads/2017/01/lugares-mais-bonitos-do-mundo.jpg","Lugares"),
                new ExplorerItem("https://gooutside-static-cdn.akamaized.net/wp-content/uploads/sites/3/2019/10/airbnb-lanca-experiencias-com-animais.jpg","Experiências"),
                new ExplorerItem("https://www.agenciatsuru.com.br/blog/wp-content/uploads/2016/07/marketing-digital-para-turismo-de-aventura-e-ecoturismo.jpg","Aventuras"),
            };
        }
    }
}
