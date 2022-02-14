using SDA.Generation;

namespace SDA.CoreGameplay
{
    public class KnifeThrow
    {
        private Knife knifeToThrow;

        public void SetKnife(Knife newKnife)
        {
            this.knifeToThrow = newKnife;

        }

        public void Throw()
        {
            if (knifeToThrow != null)
            {

                knifeToThrow.ThrowKnife();
                knifeToThrow = null;
            }
        }


    }


}