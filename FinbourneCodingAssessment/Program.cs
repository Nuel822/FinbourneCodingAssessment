// See https://aka.ms/new-console-template for more information

using FinbourneCodingAssessment;

LruCache<int, string> cache = new LruCache<int, string>(3);
cache.Add(1, "Apple");
cache.Add(2, "Orange");
cache.Add(3, "Banana");

Console.WriteLine(cache.Get(2));
Console.WriteLine(cache.Get(4));

cache.Add(4, "Coconut");
cache.Add(4, "Coconut");

Console.WriteLine(cache.Get(2));
Console.WriteLine(cache.Get(3));