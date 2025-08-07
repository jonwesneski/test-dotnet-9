using ConsoleApp1;
using ConsoleApp1.DSA;

Console.WriteLine("Hello, World!");

// var factory = new ConnectionFactory()
// {
//     HostName = "localhost",
//     UserName = "guest",
//     Password = "guest",
//     VirtualHost = "/"
// };
// var connection = await factory.CreateConnectionAsync();
// using var channel = await connection.CreateChannelAsync();
// await channel.QueueDeclareAsync("GETRECIPE", durable: true, exclusive: false);
// var consumer = new AsyncEventingBasicConsumer(channel);
// consumer.ReceivedAsync += async (model, eventArgs) =>
// {
//     var body = eventArgs.Body.ToArray();
//     var message = Encoding.UTF8.GetString(body);
//     Console.WriteLine($"recipe retrieved - {message}");
//     await Task.Delay(1);
//     return;
// };
// await channel.BasicConsumeAsync("GETRECIPE", true, consumer);
// Console.ReadKey();

// Console.WriteLine(Arrays.MajorityElement(new([3, 2, 3])));
// Console.WriteLine(Arrays.MajorityElement(new([2, 2, 1, 1, 1, 2, 2])));

// Console.WriteLine(Arrays.FirstMissingPositiveNumber([1, 2, 0]));
// Console.WriteLine(Arrays.FirstMissingPositiveNumber([3, 4, -1, 1]));
// Console.WriteLine(Arrays.FirstMissingPositiveNumber([7, 8, 9, 11, 12]));
// Console.WriteLine(Arrays.FirstMissingPositiveNumber([100000, 3, 4000, 2, 15, 1, 99999]));
// Console.WriteLine(Arrays.FirstMissingPositiveNumber([0, 2, 2, 1, 1]));

// Console.WriteLine(Arrays.GroupAnagrams(["act", "pots", "tops", "cat", "stop", "hat"]).Readable());
// Console.WriteLine(Arrays.GroupAnagrams(["x"]).Readable());
// Console.WriteLine(Arrays.GroupAnagrams([""]).Readable());

// Console.WriteLine(Arrays.FrequentK([1, 2, 2, 3, 3, 3], 2).Readable());

// Console.WriteLine(Arrays.LongestSequence([2, 20, 4, 10, 3, 4, 5]));
// Console.WriteLine(Arrays.LongestSequence([0, 3, 2, 5, 4, 6, 1, 1]));

// Console.WriteLine(PrefixSums.RangeIncrement(5, [new Tuple<int, int, int>(0, 1, 100), new Tuple<int, int, int>(1, 4, 100), new Tuple<int, int, int>(2, 3, 100)]));
// Console.WriteLine(PrefixSums.RangeIncrement(4, [new Tuple<int, int, int>(1, 2, 603), new Tuple<int, int, int>(0, 0, 286), new Tuple<int, int, int>(3, 3, 882)]));

// Console.WriteLine(PrefixSums.Equilibrium([1, 2, 0, 3]));
// Console.WriteLine(PrefixSums.Equilibrium([1, 1, 1, 1]));
// Console.WriteLine(PrefixSums.Equilibrium([1, 1, 1, 1, 1]));
// Console.WriteLine(PrefixSums.Equilibrium([-7, 1, 5, 2, -4, 3, 0]));

// Console.WriteLine(PrefixSums.LeftRight([1, 2, 3, 4, 5, 5]).Readable());
// Console.WriteLine(PrefixSums.LeftRight([4, 1, 2, 3]).Readable());
// Console.WriteLine(PrefixSums.LeftRight([4, 3, 2, 1]).Readable());

// Console.WriteLine(PrefixSums.MeanRange([3, 7, 2, 8, 5], [new Tuple<int, int>(1, 3), new Tuple<int, int>(2, 5)]).Readable());
// Console.WriteLine(PrefixSums.MeanRange([10, 20, 30, 40, 50, 60], [new Tuple<int, int>(4, 6)]).Readable());

// Console.WriteLine(PrefixSums.ProductExceptSelf([1, 2, 3, 4]).Readable());

// Console.WriteLine(SlidingWindow.FindMaxAverage([1, 12, -5, -6, 50, 3], 4));
// Console.WriteLine(SlidingWindow.FindMaxAverage([5], 1));
// Console.WriteLine(SlidingWindow.FindMaxAverage([0, 1, 1, 3, 3], 4));

//Console.WriteLine(TwoPointer.TwoSum([2, 7, 11, 15], 9).Readable());

Console.WriteLine(TwoPointer.MaxArea([1, 8, 6, 2, 5, 4, 8, 3, 7]));
Console.WriteLine(TwoPointer.MaxArea([1, 2]));
