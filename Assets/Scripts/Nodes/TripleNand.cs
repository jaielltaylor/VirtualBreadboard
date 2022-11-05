namespace MaximovInk
{
    public class TripleNand : Node
    {
        public override void OnCircuitChange()
        {
            base.OnCircuitChange();
            OutPoints[0].value = !(InPoints[0].value && InPoints[1].value);
            OutPoints[0].value = !(OutPoints[0].value && InPoints[2].value);
            OutPoints[0].OnCircuitChanged();
        }
    }
}