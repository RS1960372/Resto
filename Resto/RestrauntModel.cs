using MongoDB.Bson.Serialization.Attributes;

namespace Resto;
using MongoDB.Bson;

sealed public class RestrauntModel
{
  [BsonId] 
  public ObjectId Id { get; set; }

  public int id { get; set; }

  public string name { get; set; }
  public string neighborhood { get; set; }
  public string photograph { get; set; }
  public string address { get; set; }
  public string cuisine_type { get; set; }
  public OperatingModel operating_hours { get; set; }
  public List<ReviewModel> reviews { get; set; }
  

}

sealed public class OperatingModel
{
  [BsonId]
  public ObjectId Id { get; set; }
  public string Monday { get; set; }
  public string Tuesday { get; set; }
  public string Wednesday { get; set; }
  public string Thursday { get; set; }
  public string Friday { get; set; }
  public string Saturday { get; set; }
  public string Sunday { get; set; }
}

sealed public class ReviewModel
{
  [BsonId]
  public ObjectId Id { get; set; }
  public string name { get; set; }
  public string date { get; set; }
  public double rating { get; set; }
  public string comments { get; set; }
}

class Time // Stack Overflow :  https://stackoverflow.com/questions/2037283/how-do-i-represent-a-time-only-value-in-net
{
  public int Hours   { get; private set; }
  public int Minutes { get; private set; }
  public int Seconds { get; private set; }

  public Time(uint h, uint m, uint s)
  {
    if(h > 23 || m > 59 || s > 59)
    {
      throw new ArgumentException("Invalid time specified");
    }
    Hours = (int)h; Minutes = (int)m; Seconds = (int)s;
  }

  public Time(DateTime dt)
  {
    Hours = dt.Hour;
    Minutes = dt.Minute;
    Seconds = dt.Second;
  }

  public override string ToString()
  {  
    return String.Format(
      "{0:00}:{1:00}:{2:00}",
      this.Hours, this.Minutes, this.Seconds);
  }
}

//   "id": 1,
//   "name": "Mission Chinese Food",
//   "neighborhood": "Manhattan",
//   "photograph": "1.jpg",
//   "address": "171 E Broadway, New York, NY 10002",
//   "latlng": {
//       "lat": 40.713829,
//       "lng": -73.989667
//     },
//     "cuisine_type": "Asian",
//     "operating_hours": {
//       "Monday": "5:30 pm - 11:00 pm",
//       "Tuesday": "5:30 pm - 12:00 am",
//       "Wednesday": "5:30 pm - 12:00 am",
//       "Thursday": "5:30 pm - 12:00 am",
//       "Friday": "5:30 pm - 12:00 am",
//       "Saturday": "12:00 pm - 4:00 pm, 5:30 pm - 12:00 am",
//       "Sunday": "12:00 pm - 4:00 pm, 5:30 pm - 11:00 pm"
//     },
//     "reviews": [{
//         "name": "Steve",
//         "date": "October 26, 2016",
//         "rating": 4,
//         "comments": "Mission Chinese Food has grown up from its scrappy Orchard Street days into a big, two story restaurant equipped with a pizza oven, a prime rib cart, and a much broader menu. Yes, it still has all the hits — the kung pao pastrami, the thrice cooked bacon —but chef/proprietor Danny Bowien and executive chef Angela Dimayuga have also added a raw bar, two generous family-style set menus, and showstoppers like duck baked in clay. And you can still get a lot of food without breaking the bank."
//       },
//       {
//         "name": "Morgan",
//         "date": "October 26, 2016",
//         "rating": 4,
//         "comments": "This place is a blast. Must orders: GREEN TEA NOODS, sounds gross (to me at least) but these were incredible!, Kung pao pastrami (but you already knew that), beef tartare was a fun appetizer that we decided to try, the spicy ma po tofu SUPER spicy but delicous, egg rolls and scallion pancake i could have passed on... I wish we would have gone with a larger group, so much more I would have liked to try!"
//       },
//       {
//         "name": "Jason",
//         "date": "October 26, 2016",
//         "rating": 3,
//         "comments": "I was VERY excited to come here after seeing and hearing so many good things about this place. Having read much, I knew going into it that it was not going to be authentic Chinese. The place was edgy, had a punk rock throwback attitude, and generally delivered the desired atmosphere. Things went downhill from there though. The food was okay at best and the best qualities were easily overshadowed by what I believe to be poor decisions by the kitchen staff."
//       }
//     ]
//   }, 
// }