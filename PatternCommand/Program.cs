﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Lib;

namespace PatternCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var CP1 = new CommandProcessor();
                var ListCommand = CreateListCommand();
                CP1.ExecuteBatch(ListCommand);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Something wrong: {0}", e);
            }
            Console.ReadLine();
        }


        private static IEnumerable<ICommand> CreateListCommand()
        {
                ICommand[] cmds = new ICommand[] {
                //new MaxDate(new DateTime[] {}),
                new MaxDate(new DateTime[]
                    {new DateTime(2015, 7, 20),
                    new DateTime(2016, 7, 20),
                    new DateTime(2012, 7, 20),
                    new DateTime(2022, 7, 20)}),
                new MinDate(new DateTime[]
                    {new DateTime(2015, 7, 20),
                    new DateTime(1990, 7, 20),
                    new DateTime(2012, 7, 20),
                    new DateTime(2022, 7, 20)}),
                new PlusMonth(new DateTime(2015, 12, 20)),
                new SecToDate(875432972),
                new MaxDate(new DateTime[]
                    { new DateTime(2010, 7, 20),
                    new DateTime(2020, 7, 20) }),
                new MinDate(new DateTime[]
                    {new DateTime(2015, 7, 20),
                    new DateTime(2016, 7, 20),
                    new DateTime(1991, 7, 20),
                    new DateTime(2022, 7, 20)}),
                new PlusMonth(new DateTime(2015, 01, 20)),
                new SecToDate(1190965772),
                new MaxDate(new DateTime[]
                    { new DateTime(2000, 7, 20),
                    new DateTime(2001, 7, 20) }),
                new MinDate(new DateTime[]
                    {new DateTime(2015, 7, 20),
                    new DateTime(2016, 7, 20),
                    new DateTime(2012, 7, 20),
                    new DateTime(1992, 7, 20)}),
                new PlusMonth(new DateTime(2015, 05, 20)),
                new SecToDate(1601279372)
                };
                return cmds;
        }
    }
}
