﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalPlayingGame.Exceptions
{
    public class ImageNotFoundException: Exception
    {
        public override string Message
        {
            get
            {
                return "Изображение для предмета отсутствует";
            }
        }
    }
}
