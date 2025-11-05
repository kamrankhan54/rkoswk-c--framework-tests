using NUnit.Framework;

// Allow multiple feature files to run in parallel, but keep scenarios inside the same feature sequential
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]
