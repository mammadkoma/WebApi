namespace Utilities;

public static class DateTimeUtil
{
    public static DateTime ToMiladiDate(this String ShamsiDate_String)
    {
        if (ShamsiDate_String.Trim().Replace(" ", "").Length < 8) // تعداد ارقام کم است
            return new DateTime(1, 1, 1);

        if (ShamsiDate_String.Trim().Replace(" ", "").Length == 10) // با اسلش
        {
            String[] sp = ShamsiDate_String.Split('/');
            return new DateTime(Int32.Parse(sp[0]), Int32.Parse(sp[1]), Int32.Parse(sp[2]), new PersianCalendar());
        }
        else
        {
            string y = ShamsiDate_String.Substring(0, 4);
            string m = ShamsiDate_String.Substring(4, 2);
            string d = ShamsiDate_String.Substring(6, 2);
            return new DateTime(Int32.Parse(y), Int32.Parse(m), Int32.Parse(d), new PersianCalendar());
        }
    }

    public static String ToShamsiDate(this DateTime MiladiDate_DateTime)
    {
        PersianCalendar pc = new PersianCalendar();
        Int32 Y = pc.GetYear(MiladiDate_DateTime);
        Int32 M = pc.GetMonth(MiladiDate_DateTime);
        Int32 D = pc.GetDayOfMonth(MiladiDate_DateTime);
        String MM;
        if (M >= 1 && M <= 9)
            MM = "0" + M.ToString();
        else MM = M.ToString();
        String DD;
        if (D >= 1 && D <= 9)
            DD = "0" + D.ToString();
        else DD = D.ToString();
        return Y.ToString() + "/" + MM + "/" + DD;
    }
}
