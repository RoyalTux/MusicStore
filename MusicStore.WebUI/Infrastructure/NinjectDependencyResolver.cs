using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IMusicRepository> mock = new Mock<IMusicRepository>();
            mock.Setup(m => m.MusicTracks).Returns(new List<MusicTrack>
            {
                new MusicTrack { Name = "Audiotec & Sinerider - Physics Of Consciousness", Price = 12 },
                new MusicTrack { Name = "Cosmic Tone - Spark", Price = 10.2M },
                new MusicTrack { Name = "Modus - Sonder", Price = 11.3M }
            });
            //_kernel.Bind<IMusicRepository>().ToConstant(mock.Object);
            _kernel.Bind<IMusicRepository>().To<EfMusicRepository>();
        }
    }
}