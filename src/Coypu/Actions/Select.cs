using Coypu.Finders;

namespace Coypu.Actions
{
    internal class Select : DriverAction
    {
        private readonly DriverScope scope;
        private readonly string locator;
        private readonly string optionToSelect;
        private readonly Options options;
        private readonly DisambiguationStrategy disambiguationStrategy;

        internal Select(Driver driver, DriverScope scope, string locator, string optionToSelect, Options options, DisambiguationStrategy disambiguationStrategy)
            : base(driver, options)
        {
            this.scope = scope;
            this.locator = locator;
            this.optionToSelect = optionToSelect;
            this.options = options;
            this.disambiguationStrategy = disambiguationStrategy;
        }

        public override void Act()
        {
            var select = disambiguationStrategy.ResolveQuery(new SelectFinder(Driver, locator, scope, options));
            var option = disambiguationStrategy.ResolveQuery(new OptionFinder(Driver, optionToSelect, new SnapshotElementScope(select, scope, options), options));
            Driver.Click(option);
        }
    }
}