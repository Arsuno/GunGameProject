namespace _GunGameBattle.Source.Items.Configs
{
    public interface IItemConfigProvider
    {
        public ItemConfig GetItemConfigById(int id);
        public ItemConfig GetRandomItemConfig();
    }
}