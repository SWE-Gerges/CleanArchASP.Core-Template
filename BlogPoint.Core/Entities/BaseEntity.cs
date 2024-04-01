
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPoint.Core.Entities;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}