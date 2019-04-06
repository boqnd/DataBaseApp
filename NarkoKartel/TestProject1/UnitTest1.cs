using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SQLapp.Controller;
using SQLapp.Data;
using SQLapp.Data.Model;
using SQLapp.Service;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HireDealerTest()
        {
            var firstName = "a";
            var lastName = "b";
            var nickName = "c";
            var city = "d";
            
            var data = new List<Dealer>
            {
                new Dealer(firstName,lastName,nickName,city){Id = 1}
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Dealer>>();

            mockSet.As<IQueryable<Dealer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Dealer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Dealer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Dealer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NarkoKartelContext>();
            mockContext.Setup(c => c.Dealers).Returns(mockSet.Object);

            var service = new Commands(mockContext.Object);
            data.ToList().ForEach(d => service.Hire(d));
            
            //----    
            var dealers = service.GetAllDealers();
            
            Assert.AreEqual(dealers[0].First_Name,firstName);
            Assert.AreEqual(dealers[0].Last_Name,lastName);
            Assert.AreEqual(dealers[0].Nickname,nickName);
            Assert.AreEqual(dealers[0].CityFrom,city);  
        }
        
        [Test]
        public void AddBuyerTest()
        {
            var nickName = "c";
            var dealerId = 1;
            
            var data = new List<Buyer>
            {
                new Buyer(nickName,dealerId){Id = 1}
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Buyer>>();

            mockSet.As<IQueryable<Buyer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Buyer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Buyer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Buyer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NarkoKartelContext>();
            mockContext.Setup(c => c.Buyers).Returns(mockSet.Object);

            var service = new Commands(mockContext.Object);
            data.ToList().ForEach(d => service.Add(d));
            //----    
            var buyers = service.GetAllBuyers();
            
            Assert.AreEqual(buyers[0].Nickname,nickName);
            Assert.AreEqual(buyers[0].DealerId,dealerId);  
        }
        
        [Test]
        public void NewDrugTest()
        {
            var name = "a";
            var sellPrice = 1;
            var acquirePrice = 2;
            
            var data = new List<Drug>
            {
                new Drug(name,sellPrice,acquirePrice){Id = 1}
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Drug>>();

            mockSet.As<IQueryable<Drug>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Drug>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Drug>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Drug>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NarkoKartelContext>();
            mockContext.Setup(c => c.Drugs).Returns(mockSet.Object);

            var service = new Commands(mockContext.Object);
            data.ToList().ForEach(d => service.New(d));
            
            //----    
            var drugs = service.GetAllDrugs();
            
            Assert.AreEqual(drugs[0].Name,name);
            Assert.AreEqual(drugs[0].Sell_Price,sellPrice);
            Assert.AreEqual(drugs[0].Acquire_Price,acquirePrice);
            Assert.AreEqual(drugs[0].Quantity,2);  
        }
        
        [Test]
        public void SellTest()
        {
            var name = "a";
            var sellPrice = 1;
            var acquirePrice = 2;
            var quantity = 1;
            
            var data = new List<Drug>
            {
                new Drug(name,sellPrice,acquirePrice){Id = 1}
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Drug>>();

            mockSet.As<IQueryable<Drug>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Drug>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Drug>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Drug>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NarkoKartelContext>();
            mockContext.Setup(c => c.Drugs).Returns(mockSet.Object);

            var service = new Commands(mockContext.Object);
            data.ToList().ForEach(d => service.Sel(d,quantity));
            
            //----    
            var drugs = service.GetAllDrugs();
            
            Assert.AreEqual(drugs[0].Name,name);
            Assert.AreEqual(drugs[0].Sell_Price,sellPrice);
            Assert.AreEqual(drugs[0].Acquire_Price,acquirePrice);
            Assert.AreEqual(drugs[0].Quantity,1);  
        }
        
        [Test]
        public void BuyTest()
        {
            var name = "a";
            var sellPrice = 1;
            var acquirePrice = 2;
            var quantity = 1;
            
            var data = new List<Drug>
            {
                new Drug(name,sellPrice,acquirePrice){Id = 1}
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Drug>>();

            mockSet.As<IQueryable<Drug>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Drug>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Drug>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Drug>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NarkoKartelContext>();
            mockContext.Setup(c => c.Drugs).Returns(mockSet.Object);

            var service = new Commands(mockContext.Object);
            data.ToList().ForEach(d => service.Buy(d,quantity));
            
            //----    
            var drugs = service.GetAllDrugs();
            
            Assert.AreEqual(drugs[0].Name,name);
            Assert.AreEqual(drugs[0].Sell_Price,sellPrice);
            Assert.AreEqual(drugs[0].Acquire_Price,acquirePrice);
            Assert.AreEqual(drugs[0].Quantity,3);  
        }
        
        [Test]
        public void PaySalariesTest()
        {
            var firstName = "a";
            var lastName = "b";
            var nickName = "c";
            var city = "d";
            
            var data = new List<Dealer>
            {
                new Dealer(firstName,lastName,nickName,city){Id = 1}
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Dealer>>();

            mockSet.As<IQueryable<Dealer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Dealer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Dealer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Dealer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NarkoKartelContext>();
            mockContext.Setup(c => c.Dealers).Returns(mockSet.Object);

            var service = new Commands(mockContext.Object);
            
            var dealers = service.GetAllDealers();
            data.ToList().ForEach(d => service.Pay(dealers));
            
            //----    
            
            
            Assert.AreEqual(dealers[0].First_Name,firstName);
            Assert.AreEqual(dealers[0].Last_Name,lastName);
            Assert.AreEqual(dealers[0].Nickname,nickName);
            Assert.AreEqual(dealers[0].CityFrom,city);  
            Assert.AreEqual(dealers[0].Money_Brought_This_Month,0);  
        }
        
        [Test]
        public void KillTest()
        {
            var firstName = "a";
            var lastName = "b";
            var nickName = "c";
            var city = "d";
            
            var data = new List<Dealer>
            {
                new Dealer(firstName,lastName,nickName,city){Id = 1}
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Dealer>>();

            mockSet.As<IQueryable<Dealer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Dealer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Dealer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Dealer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NarkoKartelContext>();
            mockContext.Setup(c => c.Dealers).Returns(mockSet.Object);

            var service = new Commands(mockContext.Object);
            
            data.ToList().ForEach(d => service.Hire(d));

            var dealers = service.GetAllDealers();

            data.ToList().ForEach(d => service.Kil(d));
            
            //----    
            dealers = service.GetAllDealers();
            
            Assert.AreEqual(dealers.Count,0);
        }
    }
}











