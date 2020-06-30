﻿using GameConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bootleg_Pokémon
{
    /// <summary>
    /// Interaction logic for Pokedex.xaml
    /// </summary>
    public partial class Pokedex : Window
    {
        public GameSession Session => DataContext as GameSession;
        public Pokedex()
        {
            InitializeComponent();
        }
        private void PokedexClose_Click(object sender, RoutedEventArgs e)
        {
            Session.PokedexImage = "/GameConfig;component/Sprites/001.png";
            Close();
        }

        private void PokeName_Selected(object sender, RoutedEventArgs e)
        {
            Pokemon pokemon = Session.AllPokemon.First(p => p.Id == PokeName.SelectedIndex + 1);
            if (pokemon.EvolutionLevel == 100) { Pokevolution.Content = "Does not evolve"; }
            else { Pokevolution.Content = $"Can evolve at level {pokemon.EvolutionLevel}"; }
            Session.PokedexImage = pokemon.Image;
            PokeNameDesc.Content = pokemon.Name;
            PokeId.Content = $"#{pokemon.Id}";
            PokeType.Content = pokemon.Type[0];
            if (pokemon.Type.Length > 1)
            {
                for (int i = 1; i < pokemon.Type.Length; ++i){ PokeType.Content += $"/{pokemon.Type[i]}"; }
            }
        }
    }
}
