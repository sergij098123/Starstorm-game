using System;
using Starstorm.print;
using Starstorm.minigames;
using Starstorm.console;
using Starstorm.text;
using Starstorm.Shops;
using Starstorm.selects;

namespace Starstorm.parts{
    class Part1(){
        public static void main(){
            Print.dialoge(Text.zenon(1),"zenon");
            Print.action(Text.action(1));
            Print.action(Text.action(2));
            Print.dialoge(Text.radio(1), "radio");
            Print.action(Text.action(3));
            Print.dialoge(Text.zenon(2), "zenon");
            Print.action(Text.action(4));
            Print.dialoge(Text.radio(2), "radio");
            Print.action(Text.action(5));

            minigame1.choiсe();

            Print.action(Text.action(6));
            Print.dialoge(Text.radio(3), "radio");
            Print.dialoge(Text.zenon(3), "zenon");
            Print.dialoge(Text.radio(4), "radio");
            Print.dialoge(Text.zenon(4), "zenon");
            Print.dialoge(Text.radio(5), "radio");
            Print.dialoge(Text.zenon(5), "zenon");
            Print.dialoge(Text.radio(6), "radio");
            Print.action(Text.action(7));
            Print.dialoge(Text.zenon(6), "zenon");
            Print.dialoge(Text.radio(7), "radio");
            Print.dialoge(Text.zenon(7), "zenon");
            Print.action(Text.action(8));
            Print.dialoge(Text.radio(8), "radio");
            Print.dialoge(Text.zenon(8), "zenon");
            Print.dialoge(Text.radio(9), "radio");
            Print.action(Text.action(9));
            Print.action(Text.action(9.1));
            Print.dialoge(Text.unknown(1),"unknown");
            Print.action(Text.action(10));

            Print.action(Text.action(11));
            Print.dialoge(Text.zenon(9), "zenon");
            Print.action(Text.action(12));
            Print.dialoge(Text.zenon(10), "zenon");
            Print.action(Text.action(13));
            Print.dialoge(Text.unknown(3), "unknown");
            Print.dialoge(Text.zenon(11), "zenon");
            Print.action(Text.action(14));
            Print.dialoge(Text.radio(10), "radio");
            Print.action(Text.action(15));
            Print.dialoge(Text.unknown(4), "unknown");

            Select1.main();
        }
    }
}