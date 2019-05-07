namespace ViewPoints.DependencyServices
{
    /// <summary>
    /// Třída pro ukládání hodnot do paměti zařízení
    /// </summary>
    public abstract class ISettings
    {
        /// <summary>
        /// Uloží hodnotu do paměti zařízení. Hodnota je tedy dostupná i po vypnutí a zapnutí aplikace
        /// </summary>
        /// <param name="value">Hodnota, kterou chcete uložit</param>
        /// <param name="key">Klíč k hodnotě</param>
        public abstract void SetVariable(string value, string key);

        /// <summary>
        /// Vrátí hodnotu, kterou jste si předtím uložili do paměti zařízení. Pokud hodnota se zadaným klíčem v paměti není, vrátí defaultValue
        /// </summary>
        /// <param name="key">Klíč k hodnotě</param>
        /// <param name="defaultValue">Hodnota, která má být vrácena, pokud nebude zadaný klíč nalezen</param>
        /// <returns>Hodnota patřící k zadanému klíči</returns>
        public abstract string GetVariable(string key, string defaultValue);
    }
}
