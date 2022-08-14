using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Concrete;
using Business.Configuration.Mapper;
using DAL.Abstract;
using DTO.Apartment;
using FluentAssertions;
using Models.Entities;
using Moq;
using System;
using Xunit;

namespace Test
{
    //entegresyon testlerinde veri tabanına gidilmez.
    public class ApartmentServiceTest
    {
        [Fact]
        public void AparmentServiceCreate_Success()
        {
            //arrange--kullanılacak olan parametre ve servislerin hazırlanmasıdır
            var apartmentRepositoryMock = new Mock<IApartmentRepository>();
            //void olduğu için bir değer dönmeyecek.
            apartmentRepositoryMock.Setup(x => x.Add(It.IsAny<Home>()));

            var jobsMock = new Mock<IJobs>();
            jobsMock.Setup(x => x.DelayedJob(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<TimeSpan>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);
            
            var apartmentService =
                new ApartmentService(apartmentRepositoryMock.Object, mapper, jobsMock.Object);

            var apartmentRequest = new CreateApartmentRequest()
            {
                Block = 'A',
                Floor = "1",
                Type = "2+1",
                No=10,
                UserId=2,

            };

            //act
            var response = apartmentService.Insert(apartmentRequest);

            response.Status.Should().BeTrue();

        }
       
        [Fact]
        public void AparmentServiceDelete_Success()
        {
            //arrange
            var apartmentRepositoryMock = new Mock<IApartmentRepository>();
            //void olduğu için vir değer dönmeyecek.
            apartmentRepositoryMock.Setup(x => x.Delete(It.IsAny<Home>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);
            var jobsMock = new Mock<IJobs>();
            jobsMock.Setup(x => x.DelayedJob(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<TimeSpan>()));
            var apartmentService =
                new ApartmentService(apartmentRepositoryMock.Object, mapper, jobsMock.Object);

            var apartmentRequest = new DeleteApartmentRequest()
            {
                Id = 1,
            };

            //act
            var response = apartmentService.Delete(apartmentRequest);

            response.Status.Should().BeTrue();

        }
    }
}
