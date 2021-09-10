using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
           context.Authors.AddRange(
                        new Author{
                            Name = "İsim Test 1",
                            Surname = "Soyisim Test 1",
                            Date = new DateTime(2001, 06,12)
                        },
                        new Author{
                            Name = "İsim Test 2",
                            Surname = "Soyisim Test 2",
                            Date = new DateTime(2002, 06,12)
                        },
                        new Author{
                            Name = "İsim Test 3",
                            Surname = "Soyisim Test 3",
                            Date = new DateTime(2003, 06,12)
                        }

                    );
        }
    }
}