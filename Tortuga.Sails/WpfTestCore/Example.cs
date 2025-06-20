using Tortuga.Anchor.Modeling;

namespace WpfTestCore;

class Example : ModelBase
{
    public string? Nullable { get => Get<string?>(); set => Set(value); }
    public int? NullableInt { get => Get<int?>(); set => Set(value); }
    public string Simple { get => GetDefault<string>(""); set => Set(value); }
    public int SimpleInt { get => Get<int>(); set => Set(value); }
}
