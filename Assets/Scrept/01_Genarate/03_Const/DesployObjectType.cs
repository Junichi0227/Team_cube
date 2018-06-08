public partial class Const{

    public static string DesployObjectPath(DesployObjectType type){
        switch (type){
            case DesployObjectType.Floor:
                return type.ToString();
                break;
            case DesployObjectType.Wall:
                return type.ToString();
                break;

        }
        return null;
    }

    public enum DesployObjectType{
        //オブジェクトの種類だけ増やす
        Floor,
        Wall,
    }
}
