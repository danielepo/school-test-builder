using FeatureToggle.Toggles;

namespace FeatureToggles
{
    public class HtmlToDocumentFeature : SimpleFeatureToggle
    {
        public new bool FeatureEnabled
        {
            get { return base.FeatureEnabled; }
        }
    }
}
