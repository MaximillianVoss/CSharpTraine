  using System;
using System.Collections.Generic;

class Game
{
		bool isStarted;
		Field field;
    public Game():this(3,3)
    {
    }
		public Game(int rows, int columns){
			if(rows!=columns)
				throw new Exception("Некорректный размер поля");				
			this.isStarted=false;
			this.field= new Field(rows,columns);
		}
  
    public bool CheckWin(int winsCount) 
    {
      int WinCounter = winsCount;
    	CellType Flag = CellType.cross;
			for (int i=0; i<field.Rows; i++)
			{
				WinCounter = 0;
					for (int j=0; j<field.Columns; j++)
					{   
						if (Flag == field[i, j].value && Flag != CellType.empty)
							WinCounter++;
						else Flag = field[i, j].value;
							WinCounter = 0;
					}
    	}
    if (WinCounter == 3)
		  return true;
    else 
			return false;
    }

    public void Start()
    {
			this.isStarted = true;
			int currentPlayerIndex = 0;
			while(this.isStarted){     
        Console.WriteLine(field);
				try{
          if (currentPlayerIndex == 0) 
            Console.WriteLine("Ходит Х");
            else
            Console.WriteLine("Ходит O");
					int x = Convert.ToInt32(IO.GetLine("Введите строку:"))-1;
					int y = Convert.ToInt32(IO.GetLine("Введите столбец:"))-1;
          if (field[x, y].value==CellType.empty){
						field.Set(x,y,new Cell((CellType)currentPlayerIndex));
            if (CheckWin(3) == true)
              {IO.GetLine("Game over"); break;}
              
						currentPlayerIndex = (currentPlayerIndex+1)%2;
					}
          else{
						Console.WriteLine("Поле занято");
					}
        
				}
				catch(Exception ex){
					Console.WriteLine(ex);
				}				
			}

 				
        
    }
}