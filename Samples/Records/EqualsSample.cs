#nullable enable
using System;

namespace Records
{
    public class EqualsSample
    {
        public static void Compare()
        {
            var record1 = new Record(111);
            var record2 = new Record(111);
            
            IRecord record3 = new Record(111);
            IRecord record4 = new Record(111);
            
            Console.WriteLine(record1 == record2);
            Console.WriteLine(record3 == record4);
            Console.WriteLine(record3.Equals(record4));
        }

        interface IRecord : IEquatable<IRecord>
        {
        }

        sealed record Record : IRecord
        {
            public Record(int value)
            {
                Value = value;
            }
            
            public int Value { get; init; }
            
            public bool Equals(IRecord? other)
            {
                return other is Record otherRecord && Equals(otherRecord);
            }
        }
    }
}