using BirthdayGreetingKataService.Models;

namespace BirthdayGreetingKataService.DataProviders
{
    /// <summary>
    /// 實作此 Interface 的 classes 都要能夠提供 query 資料，並以統一格式回傳
    /// </summary>
    public interface IDataProvider
    {
        List<Member> FilterMembersByDateofBirth(int month, int day);

        List<Member> FilterMembersByGender(string gender);

        List<Member> FilterMembersByElder(int threshold = 49);
    }
}
