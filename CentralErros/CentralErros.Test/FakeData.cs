using AutoMapper;
using CentralErros.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Test
{
    public class FakeContext
    {
        private readonly string _refDataBase;

        public FakeContext(string refDataBase)
        {
            _refDataBase = refDataBase;
        }

        public Contexto GerarContexto(string inMemoriDBName)
        {
            var options = new DbContextOptionsBuilder<Contexto>()
                                .UseInMemoryDatabase(_refDataBase + "_" + inMemoriDBName)
                                .Options;
            return new Contexto(options);
        }

    }
}
