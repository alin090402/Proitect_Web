import {GetFactoryDto} from "./GetFactoryDto";
import {GetItemInventoryDto} from "./GetItemInventoryDto";

export interface GetUserWithEverythingDto{
//   public int Id { get; set; }
// public string Username { get; set; } = string.Empty;
// public double WorkExperience { get; set; }
// public UserRole Role { get; set; }
// public double Money { get; set; }
// public List<GetFactoryDto> Factories { get; set; } = new List<GetFactoryDto>();
// public List<GetItemInventoryDto> ItemInventories { get; set; } = new List<GetItemInventoryDto>();
// public DateTime? LastWorked { get; set; }

  id: number;
  username: string;
  workExperience: number;
  role: number;
  money: number;
  factories: GetFactoryDto[];
  itemInventories: GetItemInventoryDto[];
  lastWorked: Date;
}
