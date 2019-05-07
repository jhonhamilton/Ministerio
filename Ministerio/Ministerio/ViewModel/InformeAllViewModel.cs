﻿using Ministerio.Interfaces;
using Ministerio.Model;
using Ministerio.Servicio;
using Ministerio.Sqlite.Entidades;
using Ministerio.Sqlite.Repositorio;
using Ministerio.View.Popups;
using Rg.Plugins.Popup.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ministerio.ViewModel
{
    public class InformeAllViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static ObservableCollection<Informe> informes = new ObservableCollection<Informe>();
        private ObservableCollection<Mes> _meses = new ObservableCollection<Mes>();
        public ObservableCollection<Mes> Meses
        {
            get { return _meses; }
            set
            {
                _meses = value;
                OnPropertyChanged();
            }
        }
        public static ObservableCollection<Mes> Listar()
        {
            return new ObservableCollection<Mes>()
            {
                new Mes { Row = 0, Id = 9,  Indice = 9, Nombre = "Septiembre", CursosBiblicos = CursosBiblicos(9), Videos = Videos(9), Revisitas = Revisitas(9), Publicaciones = Publicaciones(9), Tiempo = TiempoMes(9) },
                new Mes { Row = 1, Id = 10, Indice = 10, Nombre = "Octubre", CursosBiblicos = CursosBiblicos(10), Videos = Videos(10), Revisitas = Revisitas(10), Publicaciones = Publicaciones(10), Tiempo = TiempoMes(10) },
                new Mes { Row = 2, Id = 11, Indice = 11, Nombre = "Noviembre", CursosBiblicos = CursosBiblicos(11), Videos = Videos(11), Revisitas = Revisitas(11), Publicaciones = Publicaciones(11), Tiempo = TiempoMes(11) },
                new Mes { Row = 3, Id = 12, Indice = 12, Nombre = "Diciembre", CursosBiblicos = CursosBiblicos(12), Videos = Videos(12), Revisitas = Revisitas(12), Publicaciones = Publicaciones(12), Tiempo = TiempoMes(12) },
                new Mes { Row = 4, Id = 1, Indice = 1, Nombre = "Enero", CursosBiblicos = CursosBiblicos(1), Videos = Videos(1), Revisitas = Revisitas(1), Publicaciones = Publicaciones(1), Tiempo = TiempoMes(1) },
                new Mes { Row = 5, Id = 2,  Indice = 2, Nombre = "Febrero", CursosBiblicos = CursosBiblicos(2), Videos = Videos(2), Revisitas = Revisitas(2), Publicaciones = Publicaciones(2), Tiempo = TiempoMes(2) },
                new Mes { Row = 6, Id = 3,  Indice = 3, Nombre = "Marzo", CursosBiblicos = CursosBiblicos(3), Videos = Videos(3), Revisitas = Revisitas(3), Publicaciones = Publicaciones(3), Tiempo = TiempoMes(3) },
                new Mes { Row = 7, Id = 4,  Indice = 4, Nombre = "Abril", CursosBiblicos = CursosBiblicos(4), Videos = Videos(4), Revisitas = Revisitas(4), Publicaciones = Publicaciones(4), Tiempo = TiempoMes(4) },
                new Mes { Row = 8, Id = 5,  Indice = 5, Nombre = "Mayo", CursosBiblicos = CursosBiblicos(5), Videos = Videos(5), Revisitas = Revisitas(5), Publicaciones = Publicaciones(5), Tiempo = TiempoMes(5) },
                new Mes { Row = 9, Id = 6,  Indice = 6, Nombre = "Junio", CursosBiblicos = CursosBiblicos(6), Videos = Videos(6), Revisitas = Revisitas(6), Publicaciones = Publicaciones(6), Tiempo = TiempoMes(6) },
                new Mes { Row = 10, Id = 7,  Indice = 7, Nombre = "Julio", CursosBiblicos = CursosBiblicos(7), Videos = Videos(7), Revisitas = Revisitas(7), Publicaciones = Publicaciones(7), Tiempo = TiempoMes(7) },
                new Mes { Row = 11, Id = 8,  Indice = 8, Nombre = "Agosto", CursosBiblicos = CursosBiblicos(8), Videos = Videos(8), Revisitas = Revisitas(8), Publicaciones = Publicaciones(8), Tiempo = TiempoMes(8) },
            };
        }
        private static string TiempoMes(int mes)
        {
            int horas = 0, minutos = 0, segundos = 0;
            var oMes = informes.Where(f => f.Fecha.Month == mes).ToList();
            foreach (var item in oMes)
            {
                segundos += item.Segundos;
                minutos += item.Minutos;
                horas += item.Hora;
            }
            return horas.ToString() + ":" + minutos.ToString() + ":" + segundos.ToString();
        }
        private static int Publicaciones(int mes)
        {
            int publicaciones = 0;
            var oMes = informes.Where(f => f.Fecha.Month == mes).ToList();
            foreach (var item in oMes)
            {
                publicaciones += (item.TratadosArticulos + item.Revistas + item.Folletos + item.Libros);
            }
            return publicaciones;
        }
        private static int Revisitas(int mes)
        {
            int revisitas = 0;
            var oMes = informes.Where(f => f.Fecha.Month == mes).ToList();
            foreach (var item in oMes)
            {
                revisitas += item.Revisitas;
            }
            return revisitas;
        }
        private static int Videos(int mes)
        {
            int videos = 0;
            var oMes = informes.Where(f => f.Fecha.Month == mes).ToList();
            foreach (var item in oMes)
            {
                videos += item.Videos;
            }
            return videos;
        }
        private static int CursosBiblicos(int mes)
        {
            int cursos = 0;
            var oMes = informes.Where(f => f.Fecha.Month == mes).ToList();
            foreach (var item in oMes)
            {
                cursos += item.CursosBiblicos;
            }
            return cursos;
        }
        public InformeAllViewModel()
        {
            informes = new InformeServicio().Consultar();
            //informes = new InformeRepositorio().ObtenerTodosInformes();
            this.Meses =  Listar();
        }        
        private bool _IsRefreshing = false;
        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set
            {
                _IsRefreshing = value;
                OnPropertyChanged();
            }
        }
        public Mes PreviousSelectedMes { get; set; }
        private Mes _SelectedMes { get; set; }
        public Mes SelectedMes
        {
            get { return _SelectedMes; }
            set
            {
                if (_SelectedMes != value)
                {
                    //_SelectedMes = value;
                    //ExpandOrCollapseSelectedItem();
                    ShowDayToDay(value.Id);
                }
            }
        }
        private void ExpandOrCollapseSelectedItem()
        {
            if (PreviousSelectedMes != null)
            {
                Meses.Where(i => i.Id == PreviousSelectedMes.Id).FirstOrDefault().IsVisible = false;
            }
            Meses.Where(i => i.Id == SelectedMes.Id).FirstOrDefault().IsVisible = true;
            PreviousSelectedMes = SelectedMes;
            //PreviousSelectedMes = null;
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    RefreshData();
                    IsRefreshing = false;
                });
            }
        }
        private void RefreshData()
        {
            MainViewModel.GetInstance().InformeView = null;
            MainViewModel.GetInstance().InformeView = new InformeViewModel();
            Meses = null;
            Meses = Listar();
            DependencyService.Get<IMessage>().LongToast("Actualizada");            
        }        
        private void ShowDayToDay(int mes)
        {
            var dayToDay = new ObservableCollection<Informe>(informes.Where(i => i.Fecha.Month == mes).ToList().OrderByDescending(i => i.Fecha));
            MainViewModel.GetInstance().ShowDayToDay = new ShowDayToDayViewModel(dayToDay);
            var showDayView = new ShowDayToDayView();
            showDayView.CallbackEvent += (object sender, object e) => RefreshData();
            PopupNavigation.Instance.PushAsync(showDayView, true);
        }
        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }
    }
}
