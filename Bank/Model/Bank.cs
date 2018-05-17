using System;
using JetBrains.Annotations;

namespace Bank.Model
{
  public class Bank
  {
    public Guid Id { get; [UsedImplicitly] private set; } = new Guid();

  }
}