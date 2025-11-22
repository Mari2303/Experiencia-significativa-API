using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace Entity.Enums
{
    public enum AccompanimentRole
    {
        [Description("Tutor")]
        tutorId = 1,

        [Description("Evaluador")]
        evaluadorId = 2,

        [Description("Tutor/Evaluador")]
        tutoEvaId = 3,

        [Description("Asesor Externo")]
        AsesorId = 4,

    }
}
