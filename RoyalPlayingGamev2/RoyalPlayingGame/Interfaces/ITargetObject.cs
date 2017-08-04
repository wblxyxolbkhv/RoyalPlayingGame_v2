﻿using System;
using System.Collections.Generic;
using System.Text;

/* Назначение: Интерфейс для любого обьекта, который можно продамажить
 * Автор: Жифарский Д.А.
 */
namespace RoyalPlayingGame.Interfaces
{
    public interface ITargetObject
    {
        int Health { get; set; }
        bool IsAlive { get; set; }
        int GotDamaged(int damage, Units.DamageType DType);
        
    }
}
