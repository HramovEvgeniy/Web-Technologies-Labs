var count = 0;
function whichButton(event)
{
if (event.button == 0)
	{
	alert("Был щелчок!");
	count = count + 1;
	if(count >= 10)
		{
		alert("Вы сломали мышь!");
		}
	}
else if (event.button == 2)
	{
	alert("Вы щелкнули правой кнопкой мыши!");
	}
else if (event.button == 1)
	{
	alert("Вы щелкнули средней кнопкой!");
	}
else
	{
	alert("Вы щелкнули мышью!");
	}
}