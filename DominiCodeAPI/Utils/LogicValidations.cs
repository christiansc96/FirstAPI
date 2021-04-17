namespace DominiCodeAPI.Utils
{
    public class LogicValidations
    {
        public bool ValidateIfDataIsNotNull(object dataFromDatabase) => dataFromDatabase != null;

        public bool IfParametersAreEquals(int idFromRoute, int modelId) => idFromRoute != modelId;
    }
}