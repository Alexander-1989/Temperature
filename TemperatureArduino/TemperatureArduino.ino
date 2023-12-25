#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27, 16, 2);

const char* clock = "MHz";
const char load = (char)37;
const char temperature = (char)223;
const char separators[] = { '^', '*', '#', '@', '$', '&', '~' };
bool isConnect = false;
String inputData;

void clearName()
{
    lcd.setCursor(0, 0);
    lcd.print("            ");
}

void setName(const String &value)
{
    clearName();
    lcd.setCursor(0, 0);
    lcd.print(value);
}

void clearTemp()
{
    lcd.setCursor(12, 0);
    lcd.print("    ");
}

void setTemp(const String &value)
{
    clearTemp();
    lcd.setCursor(15 - value.length(), 0);
    lcd.print(value + temperature);
}

void clearClock()
{
    lcd.setCursor(0, 1);
    lcd.print("            ");
}

void setClock(const String &value)
{
    clearClock();
    lcd.setCursor(0, 1);
    lcd.print(value + clock);
}

void clearLoad()
{
    lcd.setCursor(12, 1);
    lcd.print("    ");
}

void setLoad(const String &value)
{
    clearLoad();
    lcd.setCursor(15 - value.length(), 1);
    lcd.print(value + load);
}

void clearTime()
{
    lcd.setCursor(0, 0);
    lcd.print("                ");
}

void setTime(const String &value)
{
    clearTime();
    lcd.setCursor(4, 0);
    lcd.print(value);
}

void clearDate()
{
    lcd.setCursor(0, 1);
    lcd.print("                ");
}

void setDate(const String &value)
{
    clearDate();
    lcd.setCursor(3, 1);
    lcd.print(inputData);
}

void displayOn()
{
    lcd.clear();
    lcd.backlight();
}

void displayOff()
{
    lcd.clear();
    lcd.noBacklight();
}

void setup()
{
    Serial.begin(9600);
    lcd.init();
}

void loop()
{
    while (Serial.available() > 0)
    {
        if (!isConnect)
        {
            displayOn();
            isConnect = true;
        }

        char received = Serial.read();
        if (strchr(separators, received) == NULL)
        {
            inputData += received;
        }
        else
        {
            if (received == separators[0])
            {
                setName(inputData);
            }
            else if (received == separators[1])
            {
                setTemp(inputData);
            }
            else if (received == separators[2])
            {
                setClock(inputData);
            }
            else if (received == separators[3])
            {
                setLoad(inputData);
            }
            else if (received == separators[4])
            {
                setTime(inputData);
            }
            else if (received == separators[5])
            {
                setDate(inputData);
            }
            else if (received == separators[6])
            {
                displayOff();
                isConnect = false;
            }

            inputData = "";
        }
    }
}