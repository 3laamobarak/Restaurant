using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MS.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ItemType
    {
        [Description("Food")]
        Food,
        [Description("Drink")]
        Drink,
        [Description("Dessert")]
        Dessert
    }

    public enum StaffType
    {
        [Description("Manager")]
        Manager,
        [Description("Waiter")]
        Waiter,
        [Description("Chef")]
        Chef,
        [Description("Cashier")]
        Cashier
    }

    public enum TableStatus
    {
        [Description("Free")]
        Free,
        [Description("Reserved")]
        Reserved,
        [Description("Occupied")]
        Occupied
    }
    public enum GenderType
    {
        [Description]
        Male,
        [Description]
        Female
    }
}
