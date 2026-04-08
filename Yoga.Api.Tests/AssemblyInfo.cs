using Xunit;

// Serilog's ReloadableLogger (UseSerilog) is not safe when multiple WebApplicationFactory
// instances build hosts in parallel in the same process — "The logger is already frozen."
[assembly: CollectionBehavior(DisableTestParallelization = true)]
