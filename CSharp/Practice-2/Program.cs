
namespace ReadTableForm;

class Program
{
    static void Main(string[] args)
    {
        // Считываем путь до файла nikhao (1). csv
        string filePath = @"File\nikhao (1).csv";

        // Создаем коллекцию/список строк
        List<(string name, int price, string comment)> productList = new List<(string, int, string)>();
        
        // Проверяем наличие файла
        if (File.Exists(filePath))
        { 
            string[] lines = File.ReadAllLines(filePath);

            // Разбивает наш файл на строки
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                {
                    continue;
                }   
                // Создаем колонны с названиями/ценой/комментом, которые отделяет ';'
                string[] columns = line.Split(';');
                
                // Даём названия нашим колоннам
                string name = columns[0];
                string comment = columns[2];
                
                if (int.TryParse(columns[1], out int price))
                {
                    // тут всё это дело заносим в наш список/коллекцию
                    productList.Add((name, price, comment));
                }
            }
            
            // Сортируем список/коллекцию по цене от меньшего к большему
            var sortedProduct = productList.OrderBy(product => product.price);
            Console.WriteLine("Товары отсортированы по цене:");
            
            foreach (var product in sortedProduct)
            {
                Console.WriteLine($"Название: {product.name}, Цена: {product.price}, Комментарий: {product.comment}");
            }
        }
        else
        {
            Console.WriteLine("File not found");
        }
    }
}


// Проложить путь до файла +
// Прочитать файл +
// Считываем его содержимое и проверка корректности +
    //Задать переменную для определению Названия, Цены и Комментария. +
        //Формат данных: name;price;comment +

// Получить отсортированный список содержимого. +
// Только корректные строки товаров, пропустив комментарии и пустые строки +

// Вывести содержимое файла +
