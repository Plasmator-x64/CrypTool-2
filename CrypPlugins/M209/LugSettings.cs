﻿namespace CrypTool.Plugins.M209
{
    class LugSettings
    {
        public static int[,] SetA = new int[,] {
	        { 1, 2, 3, 4, 8,10}, // 1
	        { 1, 2, 3, 4, 7,11}, // 1
	        { 1, 2, 3, 4, 6,12}, // 1
	        { 1, 2, 3, 4, 5,13}, // 1
	        { 1, 2, 3, 5, 8, 9}, // 1
	        { 1, 2, 3, 5, 7,10}, // 1
	        { 1, 2, 3, 5, 6,11}, // 1
	        { 1, 2, 3, 6, 7, 9}, // 1
	        { 1, 2, 4, 5, 7, 9}, // 1
	        { 1, 2, 4, 5, 6,10}, // 1
	        { 1, 2, 4, 6, 7, 8}, // 1
	        { 1, 2, 3, 4, 9,10}, // 2
	        { 1, 2, 3, 4, 8,11}, // 2
	        { 1, 2, 3, 4, 7,12}, // 2
	        { 1, 2, 3, 4, 6,13}, // 2
	        { 1, 2, 3, 5, 8,10}, // 2
	        { 1, 2, 3, 5, 7,11}, // 2
	        { 1, 2, 3, 5, 6,12}, // 2
	        { 1, 2, 3, 6, 8, 9}, // 2
	        { 1, 2, 3, 6, 7,10}, // 2
	        { 1, 2, 4, 5, 8, 9}, // 2
	        { 1, 2, 4, 5, 7,10}, // 2
	        { 1, 2, 4, 5, 6,11}, // 2
	        { 1, 2, 4, 6, 7, 9}, // 2
	        { 1, 2, 3, 4, 9,11}, // 3
	        { 1, 2, 3, 4, 8,12}, // 3
	        { 1, 2, 3, 4, 7,13}, // 3
	        { 1, 2, 3, 5, 9,10}, // 3
	        { 1, 2, 3, 5, 8,11}, // 3
	        { 1, 2, 3, 5, 7,12}, // 3
	        { 1, 2, 3, 5, 6,13}, // 3
	        { 1, 2, 3, 6, 8,10}, // 3
	        { 1, 2, 3, 6, 7,11}, // 3
	        { 1, 2, 3, 7, 8, 9}, // 3
	        { 1, 2, 4, 5, 8,10}, // 3
	        { 1, 2, 4, 5, 7,11}, // 3
	        { 1, 2, 4, 5, 6,12}, // 3
	        { 1, 2, 4, 6, 8, 9}, // 3
	        { 1, 2, 4, 6, 7,10}, // 3
	        { 1, 2, 3, 4,10,11}, // 4
	        { 1, 2, 3, 4, 9,12}, // 4
	        { 1, 2, 3, 4, 8,13}, // 4
	        { 1, 2, 3, 5, 9,11}, // 4
	        { 1, 2, 3, 5, 8,12}, // 4
	        { 1, 2, 3, 5, 7,13}, // 4
	        { 1, 2, 3, 6, 9,10}, // 4
	        { 1, 2, 3, 6, 8,11}, // 4
	        { 1, 2, 3, 6, 7,12}, // 4
	        { 1, 2, 3, 7, 8,10}, // 4
	        { 1, 2, 4, 5, 9,10}, // 4
	        { 1, 2, 4, 5, 8,11}, // 4
	        { 1, 2, 4, 5, 7,12}, // 4
	        { 1, 2, 4, 5, 6,13}, // 4
	        { 1, 2, 4, 6, 8,10}, // 4
	        { 1, 2, 4, 6, 7,11}, // 4
	        { 1, 2, 4, 7, 8, 9}, // 4
	        { 1, 2, 3, 4,10,12}, // 5
	        { 1, 2, 3, 4, 9,13}, // 5
	        { 1, 2, 3, 5,10,11}, // 5
	        { 1, 2, 3, 5, 9,12}, // 5
	        { 1, 2, 3, 5, 8,13}, // 5
	        { 1, 2, 3, 6, 9,11}, // 5
	        { 1, 2, 3, 6, 8,12}, // 5
	        { 1, 2, 3, 6, 7,13}, // 5
	        { 1, 2, 3, 7, 9,10}, // 5
	        { 1, 2, 3, 7, 8,11}, // 5
	        { 1, 2, 4, 5, 9,11}, // 5
	        { 1, 2, 4, 5, 8,12}, // 5
	        { 1, 2, 4, 5, 7,13}, // 5
	        { 1, 2, 4, 6, 9,10}, // 5
	        { 1, 2, 4, 6, 8,11}, // 5
	        { 1, 2, 4, 6, 7,12}, // 5
	        { 1, 2, 4, 7, 8,10}, // 5
	        { 1, 2, 3, 4,11,12}, // 6
	        { 1, 2, 3, 4,10,13}, // 6
	        { 1, 2, 3, 5,10,12}, // 6
	        { 1, 2, 3, 5, 9,13}, // 6
	        { 1, 2, 3, 6,10,11}, // 6
	        { 1, 2, 3, 6, 9,12}, // 6
	        { 1, 2, 3, 6, 8,13}, // 6
	        { 1, 2, 3, 7, 9,11}, // 6
	        { 1, 2, 3, 7, 8,12}, // 6
	        { 1, 2, 4, 5,10,11}, // 6
	        { 1, 2, 4, 5, 9,12}, // 6
	        { 1, 2, 4, 5, 8,13}, // 6
	        { 1, 2, 4, 6, 9,11}, // 6
	        { 1, 2, 4, 6, 8,12}, // 6
	        { 1, 2, 4, 6, 7,13}, // 6
	        { 1, 2, 4, 7, 9,10}, // 6
	        { 1, 2, 4, 7, 8,11}, // 6
	        { 1, 2, 3, 4,11,13}, // 7
	        { 1, 2, 3, 5,11,12}, // 7
	        { 1, 2, 3, 5,10,13}, // 7
	        { 1, 2, 3, 6,10,12}, // 7
	        { 1, 2, 3, 6, 9,13}, // 7
	        { 1, 2, 3, 7,10,11}, // 7
	        { 1, 2, 3, 7, 9,12}, // 7
	        { 1, 2, 3, 7, 8,13}, // 7
	        { 1, 2, 4, 5,10,12}, // 7
	        { 1, 2, 4, 5, 9,13}, // 7
	        { 1, 2, 4, 6,10,11}, // 7
	        { 1, 2, 4, 6, 9,12}, // 7
	        { 1, 2, 4, 6, 8,13}, // 7
	        { 1, 2, 4, 7, 9,11}, // 7
	        { 1, 2, 4, 7, 8,12}, // 7
	        { 1, 2, 4, 8, 9,10}, // 7
	        { 1, 2, 3, 5,11,13}, // 8
	        { 1, 2, 3, 6,11,12}, // 8
	        { 1, 2, 3, 6,10,13}, // 8
	        { 1, 2, 3, 7,10,12}, // 8
	        { 1, 2, 3, 7, 9,13}, // 8
	        { 1, 2, 4, 5,11,12}, // 8
	        { 1, 2, 4, 5,10,13}, // 8
	        { 1, 2, 4, 6,10,12}, // 8
	        { 1, 2, 4, 6, 9,13}, // 8
	        { 1, 2, 4, 7,10,11}, // 8
	        { 1, 2, 4, 7, 9,12}, // 8
	        { 1, 2, 4, 7, 8,13}, // 8
	        { 1, 2, 4, 8, 9,11}, // 8
	        { 1, 2, 3, 5,12,13}, // 9
	        { 1, 2, 3, 6,11,13}, // 9
	        { 1, 2, 3, 7,11,12}, // 9
	        { 1, 2, 3, 7,10,13}, // 9
	        { 1, 2, 4, 5,11,13}, // 9
	        { 1, 2, 4, 6,11,12}, // 9
	        { 1, 2, 4, 6,10,13}, // 9
	        { 1, 2, 4, 7,10,12}, // 9
	        { 1, 2, 4, 7, 9,13}, // 9
	        { 1, 2, 4, 8,10,11}, // 9
	        { 1, 2, 4, 8, 9,12}, // 9
	        { 1, 2, 3, 6,12,13}, // 10
	        { 1, 2, 3, 7,11,13}, // 10
	        { 1, 2, 4, 5,12,13}, // 10
	        { 1, 2, 4, 6,11,13}, // 10
	        { 1, 2, 4, 7,11,12}, // 10
	        { 1, 2, 4, 7,10,13}, // 10
	        { 1, 2, 4, 8,10,12}, // 10
	        { 1, 2, 4, 8, 9,13}, // 10
	        { 1, 2, 3, 7,12,13}, // 11
	        { 1, 2, 4, 6,12,13}, // 11
	        { 1, 2, 4, 7,11,13}, // 11
	        { 1, 2, 4, 8,11,12}, // 11
	        { 1, 2, 4, 8,10,13}, // 11
	        { 1, 2, 4, 7,12,13}, // 12
	        { 1, 2, 4, 8,11,13}, // 12
        };

        public static int[,] SetB = new int[,] {
            { 1, 1, 2, 3, 8,13}, // 1
	        { 1, 1, 2, 4, 9,11}, // 1
	        { 1, 1, 2, 4, 8,12}, // 1
	        { 1, 1, 2, 4, 7,13}, // 1
	        { 1, 1, 2, 5, 9,10}, // 1
	        { 1, 1, 2, 5, 8,11}, // 1
	        { 1, 1, 2, 5, 7,12}, // 1
	        { 1, 1, 2, 5, 6,13}, // 1
	        { 1, 1, 3, 4, 9,10}, // 1
	        { 1, 1, 3, 4, 8,11}, // 1
	        { 1, 1, 3, 4, 7,12}, // 1
	        { 1, 1, 3, 4, 6,13}, // 1
	        { 1, 1, 3, 5, 8,10}, // 1
	        { 1, 1, 3, 5, 7,11}, // 1
	        { 1, 1, 3, 5, 6,12}, // 1
	        { 1, 1, 3, 6, 8, 9}, // 1
	        { 1, 1, 3, 6, 7,10}, // 1
	        { 1, 2, 2, 3, 9,11}, // 1
	        { 1, 2, 2, 3, 8,12}, // 1
	        { 1, 2, 2, 3, 7,13}, // 1
	        { 1, 2, 2, 4, 9,10}, // 1
	        { 1, 2, 2, 4, 8,11}, // 1
	        { 1, 2, 2, 4, 7,12}, // 1
	        { 1, 2, 2, 4, 6,13}, // 1
	        { 1, 2, 2, 5, 8,10}, // 1
	        { 1, 2, 2, 5, 7,11}, // 1
	        { 1, 2, 2, 5, 6,12}, // 1
	        { 1, 2, 2, 6, 8, 9}, // 1
	        { 1, 2, 2, 6, 7,10}, // 1
	        { 1, 2, 3, 3, 9,10}, // 1
	        { 1, 2, 3, 3, 8,11}, // 1
	        { 1, 2, 3, 3, 7,12}, // 1
	        { 1, 2, 3, 3, 6,13}, // 1
	        { 1, 2, 3, 4, 9, 9}, // 1
	        { 1, 2, 3, 5, 5,12}, // 1
	        { 1, 2, 3, 6, 8, 8}, // 1
	        { 1, 2, 3, 6, 6,10}, // 1
	        { 1, 2, 3, 7, 7, 8}, // 1
	        { 1, 2, 4, 4, 8, 9}, // 1
	        { 1, 2, 4, 4, 7,10}, // 1
	        { 1, 2, 4, 4, 6,11}, // 1
	        { 1, 2, 4, 4, 5,12}, // 1
	        { 1, 2, 4, 5, 8, 8}, // 1
	        { 1, 2, 4, 5, 5,11}, // 1
	        { 1, 2, 4, 6, 6, 9}, // 1
	        { 1, 1, 2, 4, 9,12}, // 2
	        { 1, 1, 2, 4, 8,13}, // 2
	        { 1, 1, 2, 5, 9,11}, // 2
	        { 1, 1, 2, 5, 8,12}, // 2
	        { 1, 1, 2, 5, 7,13}, // 2
	        { 1, 1, 3, 4, 9,11}, // 2
	        { 1, 1, 3, 4, 8,12}, // 2
	        { 1, 1, 3, 4, 7,13}, // 2
	        { 1, 1, 3, 5, 9,10}, // 2
	        { 1, 1, 3, 5, 8,11}, // 2
	        { 1, 1, 3, 5, 7,12}, // 2
	        { 1, 1, 3, 5, 6,13}, // 2
	        { 1, 1, 3, 6, 8,10}, // 2
	        { 1, 1, 3, 6, 7,11}, // 2
	        { 1, 2, 2, 3, 9,12}, // 2
	        { 1, 2, 2, 3, 8,13}, // 2
	        { 1, 2, 2, 4, 9,11}, // 2
	        { 1, 2, 2, 4, 8,12}, // 2
	        { 1, 2, 2, 4, 7,13}, // 2
	        { 1, 2, 2, 5, 9,10}, // 2
	        { 1, 2, 2, 5, 8,11}, // 2
	        { 1, 2, 2, 5, 7,12}, // 2
	        { 1, 2, 2, 5, 6,13}, // 2
	        { 1, 2, 2, 6, 8,10}, // 2
	        { 1, 2, 2, 6, 7,11}, // 2
	        { 1, 2, 3, 3, 9,11}, // 2
	        { 1, 2, 3, 3, 8,12}, // 2
	        { 1, 2, 3, 3, 7,13}, // 2
	        { 1, 2, 3, 5, 9, 9}, // 2
	        { 1, 2, 3, 5, 5,13}, // 2
	        { 1, 2, 3, 6, 6,11}, // 2
	        { 1, 2, 3, 7, 8, 8}, // 2
	        { 1, 2, 3, 7, 7, 9}, // 2
	        { 1, 2, 4, 4, 8,10}, // 2
	        { 1, 2, 4, 4, 7,11}, // 2
	        { 1, 2, 4, 4, 6,12}, // 2
	        { 1, 2, 4, 4, 5,13}, // 2
	        { 1, 2, 4, 5, 5,12}, // 2
	        { 1, 2, 4, 6, 8, 8}, // 2
	        { 1, 2, 4, 6, 6,10}, // 2
	        { 1, 2, 4, 7, 7, 8}, // 2
	        { 1, 1, 2, 4, 9,13}, // 3
	        { 1, 1, 2, 5,10,11}, // 3
	        { 1, 1, 2, 5, 9,12}, // 3
	        { 1, 1, 2, 5, 8,13}, // 3
	        { 1, 1, 3, 4,10,11}, // 3
	        { 1, 1, 3, 4, 9,12}, // 3
	        { 1, 1, 3, 4, 8,13}, // 3
	        { 1, 1, 3, 5, 9,11}, // 3
	        { 1, 1, 3, 5, 8,12}, // 3
	        { 1, 1, 3, 5, 7,13}, // 3
	        { 1, 1, 3, 6, 9,10}, // 3
	        { 1, 1, 3, 6, 8,11}, // 3
	        { 1, 1, 3, 6, 7,12}, // 3
	        { 1, 2, 2, 3, 9,13}, // 3
	        { 1, 2, 2, 4,10,11}, // 3
	        { 1, 2, 2, 4, 9,12}, // 3
	        { 1, 2, 2, 4, 8,13}, // 3
	        { 1, 2, 2, 5, 9,11}, // 3
	        { 1, 2, 2, 5, 8,12}, // 3
	        { 1, 2, 2, 5, 7,13}, // 3
	        { 1, 2, 2, 6, 9,10}, // 3
	        { 1, 2, 2, 6, 8,11}, // 3
	        { 1, 2, 2, 6, 7,12}, // 3
	        { 1, 2, 3, 3,10,11}, // 3
	        { 1, 2, 3, 3, 9,12}, // 3
	        { 1, 2, 3, 3, 8,13}, // 3
	        { 1, 2, 3, 4,10,10}, // 3
	        { 1, 2, 3, 6, 9, 9}, // 3
	        { 1, 2, 3, 6, 6,12}, // 3
	        { 1, 2, 3, 7, 7,10}, // 3
	        { 1, 2, 4, 4, 9,10}, // 3
	        { 1, 2, 4, 4, 8,11}, // 3
	        { 1, 2, 4, 4, 7,12}, // 3
	        { 1, 2, 4, 4, 6,13}, // 3
	        { 1, 2, 4, 5, 9, 9}, // 3
	        { 1, 2, 4, 5, 5,13}, // 3
	        { 1, 2, 4, 6, 6,11}, // 3
	        { 1, 2, 4, 7, 8, 8}, // 3
	        { 1, 2, 4, 7, 7, 9}, // 3
	        { 1, 1, 2, 5,10,12}, // 4
	        { 1, 1, 2, 5, 9,13}, // 4
	        { 1, 1, 3, 4,10,12}, // 4
	        { 1, 1, 3, 4, 9,13}, // 4
	        { 1, 1, 3, 5,10,11}, // 4
	        { 1, 1, 3, 5, 9,12}, // 4
	        { 1, 1, 3, 5, 8,13}, // 4
	        { 1, 1, 3, 6, 9,11}, // 4
	        { 1, 1, 3, 6, 8,12}, // 4
	        { 1, 1, 3, 6, 7,13}, // 4
	        { 1, 2, 2, 4,10,12}, // 4
	        { 1, 2, 2, 4, 9,13}, // 4
	        { 1, 2, 2, 5,10,11}, // 4
	        { 1, 2, 2, 5, 9,12}, // 4
	        { 1, 2, 2, 5, 8,13}, // 4
	        { 1, 2, 2, 6, 9,11}, // 4
	        { 1, 2, 2, 6, 8,12}, // 4
	        { 1, 2, 2, 6, 7,13}, // 4
	        { 1, 2, 3, 3,10,12}, // 4
	        { 1, 2, 3, 3, 9,13}, // 4
	        { 1, 2, 3, 5,10,10}, // 4
	        { 1, 2, 3, 6, 6,13}, // 4
	        { 1, 2, 3, 7, 9, 9}, // 4
	        { 1, 2, 3, 7, 7,11}, // 4
	        { 1, 2, 4, 4, 9,11}, // 4
	        { 1, 2, 4, 4, 8,12}, // 4
	        { 1, 2, 4, 4, 7,13}, // 4
	        { 1, 2, 4, 6, 9, 9}, // 4
	        { 1, 2, 4, 6, 6,12}, // 4
	        { 1, 2, 4, 7, 7,10}, // 4
	        { 1, 1, 2, 5,10,13}, // 5
	        { 1, 1, 3, 4,10,13}, // 5
	        { 1, 1, 3, 5,10,12}, // 5
	        { 1, 1, 3, 5, 9,13}, // 5
	        { 1, 1, 3, 6,10,11}, // 5
	        { 1, 1, 3, 6, 9,12}, // 5
	        { 1, 1, 3, 6, 8,13}, // 5
	        { 1, 2, 2, 4,10,13}, // 5
	        { 1, 2, 2, 5,10,12}, // 5
	        { 1, 2, 2, 5, 9,13}, // 5
	        { 1, 2, 2, 6,10,11}, // 5
	        { 1, 2, 2, 6, 9,12}, // 5
	        { 1, 2, 2, 6, 8,13}, // 5
	        { 1, 2, 3, 3,10,13}, // 5
	        { 1, 2, 3, 4,11,11}, // 5
	        { 1, 2, 3, 6,10,10}, // 5
	        { 1, 2, 3, 7, 7,12}, // 5
	        { 1, 2, 4, 4,10,11}, // 5
	        { 1, 2, 4, 4, 9,12}, // 5
	        { 1, 2, 4, 4, 8,13}, // 5
	        { 1, 2, 4, 5,10,10}, // 5
	        { 1, 2, 4, 6, 6,13}, // 5
	        { 1, 2, 4, 7, 9, 9}, // 5
	        { 1, 2, 4, 7, 7,11}, // 5
	        { 1, 2, 4, 8, 8, 9}, // 5
	        { 1, 1, 3, 5,11,12}, // 6
	        { 1, 1, 3, 5,10,13}, // 6
	        { 1, 1, 3, 6,10,12}, // 6
	        { 1, 1, 3, 6, 9,13}, // 6
	        { 1, 2, 2, 5,11,12}, // 6
	        { 1, 2, 2, 5,10,13}, // 6
	        { 1, 2, 2, 6,10,12}, // 6
	        { 1, 2, 2, 6, 9,13}, // 6
	        { 1, 2, 3, 5,11,11}, // 6
	        { 1, 2, 3, 7,10,10}, // 6
	        { 1, 2, 3, 7, 7,13}, // 6
	        { 1, 2, 4, 4,10,12}, // 6
	        { 1, 2, 4, 4, 9,13}, // 6
	        { 1, 2, 4, 6,10,10}, // 6
	        { 1, 2, 4, 7, 7,12}, // 6
	        { 1, 2, 4, 8, 9, 9}, // 6
	        { 1, 2, 4, 8, 8,10}, // 6
	        { 1, 1, 3, 5,11,13}, // 7
	        { 1, 1, 3, 6,11,12}, // 7
	        { 1, 1, 3, 6,10,13}, // 7
	        { 1, 2, 2, 5,11,13}, // 7
	        { 1, 2, 2, 6,11,12}, // 7
	        { 1, 2, 2, 6,10,13}, // 7
	        { 1, 2, 3, 6,11,11}, // 7
	        { 1, 2, 4, 4,11,12}, // 7
	        { 1, 2, 4, 4,10,13}, // 7
	        { 1, 2, 4, 5,11,11}, // 7
	        { 1, 2, 4, 7,10,10}, // 7
	        { 1, 2, 4, 7, 7,13}, // 7
	        { 1, 2, 4, 8, 8,11}, // 7
	        { 1, 1, 3, 6,11,13}, // 8
	        { 1, 2, 2, 6,11,13}, // 8
	        { 1, 2, 3, 5,12,12}, // 8
	        { 1, 2, 3, 7,11,11}, // 8
	        { 1, 2, 4, 4,11,13}, // 8
	        { 1, 2, 4, 6,11,11}, // 8
	        { 1, 2, 4, 8,10,10}, // 8
	        { 1, 2, 4, 8, 8,12}, // 8
	        { 1, 1, 3, 6,12,13}, // 9
	        { 1, 2, 2, 6,12,13}, // 9
	        { 1, 2, 3, 6,12,12}, // 9
	        { 1, 2, 4, 4,12,13}, // 9
	        { 1, 2, 4, 5,12,12}, // 9
	        { 1, 2, 4, 7,11,11}, // 9
	        { 1, 2, 4, 8, 8,13}, // 9
	        { 1, 2, 3, 7,12,12}, // 10
	        { 1, 2, 4, 6,12,12}, // 10
	        { 1, 2, 4, 8,11,11}, // 10
	        { 1, 2, 3, 6,13,13}, // 11
	        { 1, 2, 4, 5,13,13}, // 11
	        { 1, 2, 4, 7,12,12}, // 11
	        { 1, 2, 3, 7,13,13}, // 12
	        { 1, 2, 4, 6,13,13}, // 12
	        { 1, 2, 4, 8,12,12}, // 12
        };
    }
}
